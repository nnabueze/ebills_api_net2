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

            CollectionRequest.COLLECTION_ID = RandomNumber();

            pos_collection CollectionMap = Mapper.Map<CollectionDTO,pos_collection>(CollectionRequest);
            var CollectionResponse = _db.pos_collections.Add(CollectionMap);
            _db.SaveChanges();

            CollectionDTO CollectionResponseDTO = Mapper.Map<pos_collection,CollectionDTO>(CollectionResponse);

            return CollectionResponseDTO;
        }

        //generating ranmdom number
        public string RandomNumber()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            string rNum = DateTime.Now.Millisecond + rnd.Next(0, 900000000).ToString();

            return rNum;
        }

    }
}