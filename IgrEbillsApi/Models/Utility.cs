using IgrEbillsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IgrEbillsApi.Models
{
    public class Utility
    {
        private ValidationRequest vResponse = new ValidationRequest();
        private ValidationResponse sResponse = new ValidationResponse();
        private Field FieldItem = new Field();

        private string name;
        private string phone;
        private string address;
        private string email;

        private igrdbEntities5 db = new igrdbEntities5();

        public Utility(ValidationRequest xRequest)
        {
            vResponse = xRequest;
        }

        public Utility()
        {

        }

        //priavte class to get response
        public ValidationResponse GetMdaResponse(int num, string billerid)
        {
            sResponse.BillerName = vResponse.BillerName;
            sResponse.BillerID = vResponse.BillerID;
            sResponse.ProductName = vResponse.ProductName;
            sResponse.NextStep = num;
            sResponse.ResponseCode = "00";
            sResponse.ResponseMessage = "Successful";
            sResponse.Param = vResponse.Param;
            sResponse.field = GetMdaField(billerid);

            return sResponse;
        }

        //


        //return field
        //passing the biller id
        public Field GetMdaField(String id)
        {            
            IList<Item> result = new List<Item>();
            var mda = db.mdas.Where(o=>o.IGR_ID == id);

            foreach (var item in mda)
            {
                Item ItemParam = new Item();

                ItemParam.Name = item.MDA_Name;
                ItemParam.value = item.MDA_ID;

                result.Add(ItemParam);
            }

            FieldItem.Name = "Lga";
            FieldItem.Type = "List";
            FieldItem.Required = false;
            FieldItem.Readonly = false;
            FieldItem.MaxLength = 0;
            FieldItem.Order = 0;
            FieldItem.RequiredInNextStep = true;
            FieldItem.AmountField = false;
            FieldItem.Item = result;

            return FieldItem;

        }

        //priavte class to get response
        public ValidationResponse GetSubheadResponse(int num, string mdaid)
        {
            sResponse.BillerName = vResponse.BillerName;
            sResponse.BillerID = vResponse.BillerID;
            sResponse.ProductName = vResponse.ProductName;
            sResponse.NextStep = num;
            sResponse.ResponseCode = "00";
            sResponse.ResponseMessage = "Successful";
            sResponse.Param = vResponse.Param;
            sResponse.field = GetSubheadField(mdaid);

            return sResponse;
        }


        public Field GetSubheadField(String mda)
        {
            FieldItem = new Field();
            

            FieldItem.Name = "Subhead";
            FieldItem.Type = "List";
            FieldItem.Required = false;
            FieldItem.Readonly = false;
            FieldItem.MaxLength = 0;
            FieldItem.Order = 0;
            FieldItem.RequiredInNextStep = true;
            FieldItem.AmountField = false;
            FieldItem.Item = GetSubheadJoin(mda);

            return FieldItem;

        }

        //getting list of subhead
        public IList<Item> GetSubheadJoin(string mdaid)
        {
            IList<Item> result = new List<Item>();            
            var revenueList = db.revenueheads.Where(o=>o.MDA_ID == mdaid).ToList();

            foreach (var item in revenueList)
            {
                var subheadList = db.subheads.Where(o=>o.RevHead_ID == item.ID);

                foreach (var items in subheadList)
                {
                    Item ItemParam = new Item();

                    ItemParam.Name = items.SubHead_Name;
                    ItemParam.value = items.SubHead_ID;

                    result.Add(ItemParam);
                }
            }

            return result;
        }

        public ValidationResponse GetResponse(int num)
        {
            sResponse.BillerName = vResponse.BillerName;
            sResponse.BillerID = vResponse.BillerID;
            sResponse.ProductName = vResponse.ProductName;
            sResponse.NextStep = num;
            sResponse.ResponseCode = "00";
            sResponse.ResponseMessage = "Successful";
            sResponse.Param = vResponse.Param;

            return sResponse;
        }

        public ValidationResponse GetRemittanceResponse(ValidationRequest vResponse, int num, string remittanceid, string billerid)
        {
            sResponse.BillerName = vResponse.BillerName;
            sResponse.BillerID = vResponse.BillerID;
            sResponse.ProductName = vResponse.ProductName;
            sResponse.NextStep = num;
            sResponse.ResponseCode = "00";
            sResponse.ResponseMessage = "Successful";

            
            sResponse.Param = GetRemittanceParam(remittanceid, billerid);

            return sResponse;
        }

        //getting remittance param
        public IList<Param> GetRemittanceParam(string remittanceid, string biller)
        {
            remittance rem = db.remittances.Where(o => o.remittance_id == remittanceid).FirstOrDefault();
            Dictionary<string, string> remittance_array = new Dictionary<string, string>();

            if (rem == null)
            {
                return null;
            }

            remittance_array.Add("mda_key", rem.MDA_ID);
            remittance_array.Add("Remittance", rem.remittance_id);
            remittance_array.Add("amount", rem.amount.ToString());
            remittance_array.Add("ercasBillerId", biller);

            IList<Param> remittance_list = new List<Param>();

            foreach (var item in remittance_array)
            {
                Param p = new Param();
                p.key = item.Key;
                p.value = item.Value;

                remittance_list.Add(p);
            }

            return remittance_list;
        }

        public ValidationResponse GetInvoiceResponse(int num, string invoiceid, string billerid)
        {
            sResponse.BillerName = vResponse.BillerName;
            sResponse.BillerID = vResponse.BillerID;
            sResponse.ProductName = vResponse.ProductName;
            sResponse.NextStep = num;
            sResponse.ResponseCode = "00";
            sResponse.ResponseMessage = "Successful";

            sResponse.Param = GetInvoiceParam(invoiceid, billerid);



            return sResponse;
        }

        public IList<Param> GetInvoiceParam(string invoiceid, string biller)
        {
            invoice rem = db.invoices.Where(o => o.invoice_id == invoiceid).FirstOrDefault();
            Dictionary<string, string> invoice_array = new Dictionary<string, string>();

            if (rem == null)
            {
                return null;
            }

            invoice_array.Add("mda_key", rem.MDA_ID);
            invoice_array.Add("Invoice", rem.invoice_id);
            invoice_array.Add("name", rem.name);
            invoice_array.Add("phone", rem.phone);
            invoice_array.Add("amount", rem.amount.ToString());
            invoice_array.Add("ercasBillerId", biller);

            IList<Param> invoice_list = new List<Param>();

            foreach (var item in invoice_array)
            {
                Param p = new Param();
                p.key = item.Key;
                p.value = item.Value;

                invoice_list.Add(p);
            }

            return invoice_list;
        }

        //getting tin verification
        public IList<Param> TinVerify(string tin, string billerid)
        {
            IList<Param> Result = new List<Param>();

            var tinDetails = db.tins.Where(o=>o.tin_no==tin || o.temporary_tin == tin).FirstOrDefault();

            if (tinDetails != null)
            {
                IList<Param> tinParam = TinParamArray(tinDetails);

                if (tinParam.Count > 0)
                {
                    return tinParam;
                }
            }


            return null;
        }

        //returning tin param
        public IList<Param> TinParamArray(tin tin)
        {
            Dictionary<string, string> Result = new Dictionary<string, string>();
            IList<Param> tinParam = new List<Param>();

            Result.Add("nama",tin.name);
            Result.Add("phone", tin.phone);
            Result.Add("email",tin.email);
            Result.Add("address",tin.address);

            foreach (var item in Result)
            {
                Param p = new Param();
                p.key = item.Key;
                p.value = item.Value;

                tinParam.Add(p);

            }

            return tinParam;

        }

        //Getting tin verification response
        public ValidationResponse GetTinResponse(int num,string tin, string billerid)
        {
            sResponse.BillerName = vResponse.BillerName;
            sResponse.BillerID = vResponse.BillerID;
            sResponse.ProductName = vResponse.ProductName;
            sResponse.NextStep = num;
            sResponse.ResponseCode = "00";
            sResponse.ResponseMessage = "Successful";
            sResponse.Param = TinVerify(tin,billerid);
            sResponse.field = GetMdaField(billerid);

            return sResponse;
        }

        //inserting notification
        public notification InsertNotification(notification notify)
        {
            var notifyResponse = db.notifications.Add(notify);

            db.SaveChanges();

            return notifyResponse;
        }

        public tin tinCode()
        {

            IList<Param> sList = vResponse.Param;

            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].key.Equals("name"))
                {
                    name = sList[i].value;
                }

                if (sList[i].key.Equals("phone"))
                {
                    phone = sList[i].value;
                }

                if (sList[i].key.Equals("address")) 
                {
                    address = sList[i].value;
                }

                if (sList[i].key.Equals("email")) 
                {
                    email = sList[i].value;
                }
                
            }

            tin tinParam = new tin();
            tinParam.name = name;
            tinParam.phone = phone;
            tinParam.address = address;
            tinParam.email = email;

            var tinRecord = db.tins.Add(tinParam);

            db.SaveChanges();

            Console.WriteLine(tinRecord);


            return tinRecord;



        }

    }
}