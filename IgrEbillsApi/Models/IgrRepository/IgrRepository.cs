using IgrEbillsApi.Models.pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IgrEbillsApi.Models.IgrRepository
{
    public class IgrRepository
    {
        private igrdbEntities3 db;

        public IgrRepository()
        {
            db = new igrdbEntities3();
        }

        //getting list of igr
        public IEnumerable<igr> GetIgrList()
        {
            var igrList = db.igrs.ToList();

            return igrList;
        }

        //getting a single igr
        public igr GetIgr(string id)
        {
            var igr = db.igrs.FirstOrDefault(o=>o.IGR_Code == id);

            return igr;
        }

        //getting list of Mda
        public IEnumerable<mda> GetMdaList()
        {
            var mdaList = db.mdas.ToList();

            return mdaList;
        }

        //getting a single mda
        public mda GetMda(string id)
        {
            var mda = db.mdas.FirstOrDefault(o=>o.IGR_ID == id);

            return mda;
        }

        //getting list of subhead
        public IEnumerable<subhead> GetSubheadList()
        {
            var subheadList = db.subheads.ToList();

            return subheadList;
        }

        //get a single subhead 
        public subhead GetSubhead(string id)
        {
            var subhead = db.subheads.FirstOrDefault(o=>o.SubHead_ID == id);
            return subhead;
        }
    }
}