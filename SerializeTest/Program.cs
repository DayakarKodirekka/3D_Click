using System;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text;
using System.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;

namespace Program
{

    // public class FloatJsonConverterToNumber4D : JsonConverter<float>   // the number is written as a number, without quotes: ("previousClose":"272.4800109863281") should be ("previousClose":272.48) 
    // {
    //     public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
    //             Single.Parse(reader.GetString() ?? string.Empty);

    //     public override void Write(Utf8JsonWriter writer, float p_value, JsonSerializerOptions options)
    //     {
    //         // https://github.com/dotnet/runtime/issues/31024
    //         // ArgumentException' in System.Text.Json.dll: '.NET number values such as positive and negative infinity cannot be written as valid JSON.'
    //         // This is a more complicated scenario as some floating-point values (+infinity, -infinity, and NaN) can't be represented as JSON "numbers".
    //         // The only way these can be successfully serialized/deserialized is by representing them by using an alternative format (such as strings).
    //         // Writes ["Infinity","NaN",0.1,1.0002,3.141592653589793]
    //         // And the following succeeds: JsonConvert.DeserializeObject<double[]>("[\"Infinity\",\"NaN\",0.1,1.0002,3.141592653589793]");
    //         if (float.IsFinite(p_value))
    //         {
    //             writer.WriteNumberValue(Convert.ToDecimal(Math.Round(p_value, 4))); // use 4 decimals instead of 2, because of penny stocks and MaxDD of "-0.2855" means -28.55%. ToString(): 24.00155 is rounded up to 24.0016
    //         }
    //         else
    //         {
    //             writer.WriteStringValue(p_value.ToString());
    //         }
    //     }
    // }
    class AssetJs   // the class Asset converted to the the JS client. Usually it is sent to client tool in the Handshake msg. It can be used later for AssetId to Asset connection.
    {
        public uint AssetId { get; set; } = 0; // invalid value is best to be 0. If it is Uint32.MaxValue is the invalid, then problems if extending to Uint6

         //[JsonConverter(typeof(FloatJsonConverterToNumber4D))]
        public string Name { get; set; } = string.Empty;    // if the client has to show the name on the UI.

        // [JsonConverter(typeof(FloatJsonConverterToNumber4D))]
        // public float Last { get; set; } = -100.0f;     // real-time last price
    }



    public class NewBaseType
    {
        static JsonSerializerOptions g_camelJsonSerializeOpt = new JsonSerializerOptions
        // static JsonSerializerOptions g_camelJsonSerializeOpt = new(JsonSerializerDefaults.Web)
        {
            // PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            // DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            //Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
            // Converters = { new DictionaryWithNamingPolicyConverter(JsonNamingPolicy.CamelCase) },
        };

        public NewBaseType()
        {
        }

        // static JsonSerializerSettings  = new JsonSerializerSettings {
        //     StringEscapeHandling = StrinEscapeHandling.EscapeNonAscii
        // };
        public static void Main()
        {
            // string encodedText = "Tend&#234;ncias de Desfiles";

            // string decodedText = HttpUtility.HtmlDecode(encodedText);
            // Console.OutputEncoding = System.Text.Encoding.UTF8;

            AssetJs asset = new AssetJs() { AssetId=11, Name = "SPDR S&P 500 ETF Trust"};

            string serializedText = JsonSerializer.Serialize(asset, g_camelJsonSerializeOpt);
            
            // string serializedText = JsonSerializer.Serialize(asset);
            // string result = serializedText.Replace("","");
            // string encodedText = JsonSerializer.Serialize(asset, g_camelJsonSerializeOpt);
            // string decodedText = HttpUtility.HtmlDecode(encodedText);


            Console.WriteLine(serializedText);
            // Console.WriteLine(decodedText);

        }
    }

}