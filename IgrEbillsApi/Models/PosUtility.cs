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
    }
}