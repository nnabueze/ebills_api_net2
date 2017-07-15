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

            var posDetails = _db.pos.Where(o=>o.ActivationCode == User.ActivationCode)
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
            UserResponseDTO.ActivationCode = posDetails.ActivationCode;

            return UserResponseDTO;
        }

        //getting Mapped User DTO
        public UserDTO GetUserDTO(aspnetuser user)
        {
            return Mapper.Map<aspnetuser,UserDTO>(user);
        }

    }
}