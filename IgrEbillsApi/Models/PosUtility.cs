using AutoMapper;
using IgrEbillsApi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.Models
{
    public class PosUtility
    {
        private IgrAdo _db;

        public PosUtility()
        {
            _db = new IgrAdo();
        }

        protected void Dispose()
        {
            _db.Dispose();
        }

        //return pos details
        public PosDTO GetPos(PosDTO Pos)
        {
            PosDTO posActivation = new PosDTO();
            var Posdetails = _db.pos.Where(c => c.ActivationCode == Pos.ActivationCode)
                                    .SingleOrDefault();

            if (Posdetails == null)
            {
                return posActivation;
            }

            Posdetails.Activation = true;

            _db.SaveChanges();

            posActivation = Mapper.Map<pos,PosDTO>(Posdetails);

            return posActivation;

            
        }

        //getting Pos user login details
        public UserDTO GetPosUser(UserDTO User)
        {
            var userDetatils = _db.aspnetusers.Where(o => o.PhoneNumber == User.Phone && o.Pin == User.Pin)
                                .SingleOrDefault();

            var posDetails = _db.pos.Where(o=>o.POS_ID == User.POS_ID)
                                    .SingleOrDefault();

            if (userDetatils == null || posDetails == null)
            {
                return null;
            }

            if (posDetails.Activation == false)
            {
                return null;
            }

            UserDTO UserResponseDTO = Mapper.Map<aspnetuser, UserDTO>(userDetatils);

            UserResponseDTO.Phone = userDetatils.PhoneNumber;
            UserResponseDTO.POS_ID = posDetails.POS_ID;
            UserResponseDTO.USER_ID = userDetatils.Id;

            return UserResponseDTO;
        }

        //get tin
        public TinDTO GetTin(TinDTO TinRequest)
        {
            var userVerify = _db.aspnetusers.Where(o => o.Id == TinRequest.USER_ID).SingleOrDefault();

            var posVerify = _db.pos.Where(o => o.POS_ID == TinRequest.POS_ID).SingleOrDefault();

            var TinVerify = _db.tins.Where(o => o.tin_no == TinRequest.TinNo || o.temporary_tin == TinRequest.TinNo)
                                            .SingleOrDefault();
            if (userVerify == null || posVerify == null || TinVerify == null)
            {
                return null;
            }

            TinDTO TinResponseDTO = Mapper.Map<tin,TinDTO>(TinVerify);

            if (string.IsNullOrEmpty(TinVerify.tin_no))
            {
                TinResponseDTO.TinNo = TinVerify.temporary_tin;
            }
            else
            {
                TinResponseDTO.TinNo = TinVerify.tin_no;
            }

            TinResponseDTO.POS_ID = posVerify.POS_ID;
            TinResponseDTO.USER_ID = userVerify.Id;

            return TinResponseDTO;
        }

        //inserting pos collection
        public CollectionDTO InsertPosCollection(CollectionDTO CollectionRequest)
        {
            var UserVerify = _db.aspnetusers.Where(o => o.Id == CollectionRequest.USER_ID).SingleOrDefault();
            var PosVerify = _db.pos.Where(o => o.POS_ID == CollectionRequest.POS_ID).SingleOrDefault();
            if (UserVerify == null || PosVerify == null)
            {
                return null;
            }

            var collectionAmount = _db.pos_collections.Where(o => o.USER_ID == CollectionRequest.USER_ID
                                                            && o.CollectionStatus == 0
                                                            && o.MDAStation_ID == CollectionRequest.MDAStation_ID)
                                                            .Select(o => o.Amount).Sum();
            var TotalAmount = collectionAmount + CollectionRequest.Amount;
            if (TotalAmount >= UserVerify.UserLimit)
            {
                CollectionRequest.Message = 1;
                return CollectionRequest;
            }

            CollectionRequest.COLLECTION_ID = "CO"+RandomNumber();

            pos_collection CollectionMap = Mapper.Map<CollectionDTO,pos_collection>(CollectionRequest);

            CollectionMap.create_at = GetCurrentDateTime();
            if (CollectionRequest.Type)
            {
                CollectionMap.CollectionType = CollectionType.Tax;
            }


            var CollectionResponse = _db.pos_collections.Add(CollectionMap);
            _db.SaveChanges();

            CollectionDTO CollectionResponseDTO = Mapper.Map<pos_collection,CollectionDTO>(CollectionResponse);

            return CollectionResponseDTO;
        }

        //generating remittance
        public RemittanceDTO GetRemittance(RemittanceDTO RemitRequest)
        {
            var UserVerify = _db.aspnetusers.Where(o => o.Id == RemitRequest.USER_ID).SingleOrDefault();
            var PosVerify = _db.pos.Where(o => o.POS_ID == RemitRequest.POS_ID).SingleOrDefault();
            if (UserVerify==null || PosVerify==null)
            {
                return null;
            }

                var RemitStatus = _db.remittances.Where(o => o.USER_ID == RemitRequest.USER_ID
                                                && o.remittance_status == 0
                                                && o.MDAStation_ID == RemitRequest.MDAStation_ID)
                                                .SingleOrDefault();

                if (RemitStatus != null)
                {
                    RemitRequest.Message = 1;
                    return RemitRequest;
                }

                var collection = _db.pos_collections.Where(o => o.USER_ID == RemitRequest.USER_ID
                                                            && o.CollectionStatus == 0
                                                            && o.MDAStation_ID == RemitRequest.MDAStation_ID)
                                                            .FirstOrDefault();
                if (collection == null)
                {
                    RemitRequest.Message = 2;
                    return RemitRequest;
                }

                var collectionAmount = _db.pos_collections.Where(o => o.USER_ID == RemitRequest.USER_ID
                                                            && o.CollectionStatus == 0
                                                            && o.MDAStation_ID == RemitRequest.MDAStation_ID)
                                                            .Select(o => o.Amount).Sum();

                remittance RemiteMap = Mapper.Map<RemittanceDTO, remittance>(RemitRequest);
                RemiteMap.amount = collectionAmount;
                RemiteMap.remittance_id = "RE" + RandomNumber();
                RemiteMap.create_at = GetCurrentDateTime();

                var RemiteResponse = _db.remittances.Add(RemiteMap);
                _db.SaveChanges();



            RemittanceDTO RemiteResponseDTO = Mapper.Map<remittance, RemittanceDTO>(RemiteResponse);

            return RemiteResponseDTO;
        }

        //updating pos collection status
        public void UpdateCollection(RemittanceDTO RemitRequest)
        {
            var CollectionRemite = _db.pos_collections.Where(o => o.USER_ID == RemitRequest.USER_ID
                                                        && o.CollectionStatus == 0
                                                        && o.MDAStation_ID == RemitRequest.MDAStation_ID)
                                                        .ToList();
            foreach (var item in CollectionRemite)
            {
                item.remittance_id = RemitRequest.remittance_id;
                item.CollectionStatus = CollectionStatus.Remitted;
                _db.SaveChanges();
            }
        }

        //generating ranmdom number
        public string RandomNumber()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            string rNum = DateTime.Now.Millisecond + rnd.Next(0, 900000000).ToString();

            return rNum;
        }

        //getting current date time
        public DateTime GetCurrentDateTime()
        {
            var dt = DateTime.Now;
            DateTime dtFormated = DateTime.Parse(String.Format("{0:yyyy-MM-dd HH:mm:ss}", dt));
            return dtFormated;
        }

    }
}