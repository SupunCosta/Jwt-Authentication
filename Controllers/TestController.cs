using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using System.Globalization;
using System.Text.RegularExpressions;
using JwtAuthentication.Areas.Identity.Data.User;
using JwtAuthentication.Areas.Identity.Data;
using JwtAuthentication.Migrations;

namespace JwtAuthentication.Controllers
{
    public class TestController :Controller
    {

        [HttpGet]
        [Route("{param}")]
        public string Get(string param)
        {
            return $"The value of the parameter is: {param}";
        }


        [HttpPost]
        [Route("TestData")]
        public bool TestData([FromBody] obj request)
        {
            var timeSlots = new List<TimeSlots>()
            {

                    new TimeSlots()
                    {
                        STime = "11:00",
                        ETime = "15:00"
                    },
                    new TimeSlots()
                    {
                        STime = "18:00",
                        ETime = "22:00"
                    }



            };

            var obj1 = new TimeSlots()
            {
                STime = "07:00",
                ETime = "09:00"
            };

            var arry = new List<int>();

            foreach (var timeSlot in timeSlots)
            {
                var itemSTime = DateTime.ParseExact(timeSlot.STime,"HH:mm", CultureInfo.InvariantCulture);
                var itemETime = DateTime.ParseExact(timeSlot.ETime, "HH:mm", CultureInfo.InvariantCulture);

                var time1 = itemSTime.TimeOfDay;
                var time2 = itemETime.TimeOfDay;

                var time3 = request.Start?.TimeOfDay;
                var time4 = request.End?.TimeOfDay;

                if (!(time3 >= time1 && time4 <= time2))
                {

                    arry.Add(1);

                }
                else
                {
                    arry.Add(0);

                }


            }

            return !arry.Any(x => x == 0);



            
        }


        [HttpPost]
        [Route("DateConflict")]
        public obj DateConflict([FromBody] obj request)
        {

            //DateTime s1 = DateTime.Parse("2023-05-30T08:00:00.000Z");
            //DateTime s2 = DateTime.Parse("2023-05-30T12:00:00.000Z");
            //DateTime e1 = DateTime.Parse("2023-05-30T10:00:00.000Z");
            //DateTime e2 = DateTime.Parse("2023-05-30T13:00:00.000Z");


            if (request.Start < request.E2 && request.End > request.E1)
            {
                request.IsError = true;
            }
            //}else if(request.End > request.E1 || request.End < request.E2)
            //{
            //    request.IsError = true;
            //}

            return request;




        }


        [HttpGet]
        [Route("bmTest")]
        public bool DateConflict( string mc)
        {

            var s1 = "PM";
            var s2 = mc;
            var containsBothValues = false;

            if (mc == null)
            {
                return containsBothValues;
            }

            var pattern = "[" + Regex.Escape(s1.ToLower()) + "]";
            var result = Regex.Replace(s2.ToLower(), pattern, "");

            containsBothValues = result.Length == s2.Length - s1.Length;


            return containsBothValues;




        }
    }

}

