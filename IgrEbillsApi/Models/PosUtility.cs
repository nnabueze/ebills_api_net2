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
    }
}