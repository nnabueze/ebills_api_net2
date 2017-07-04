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

        private igrdbEntities4 db = new igrdbEntities4();

        public Utility(ValidationRequest xRequest)
        {
            vResponse = xRequest;
        }

        //priavte class to get response
        public ValidationResponse GetMdaResponse(ValidationRequest vResponse, int num, string billerid)
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
    }
}