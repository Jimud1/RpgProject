using Newtonsoft.Json;
using System;
using System.IO;

namespace Assets.Scripts.Util
{
    public static class JsonHelper 
    {
        /// <summary>
        /// Convert Josn to model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToModel<T>(string json)
        {
            T model;
            //Ignore null values
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            
            try
            {
                model = JsonConvert.DeserializeObject<T>(json, settings);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured trying to convert json into Story Model", ex);
            }

            return model;
        }

        public static string GetJsonFromFile(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured trying to read all text from " + filePath, ex);
            }
        }
    }
}