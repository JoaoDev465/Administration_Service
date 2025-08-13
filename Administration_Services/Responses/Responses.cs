using System.Text.Json.Serialization;

namespace Administration_Services.Responses;

public class Responses<TData>
{
    
    [JsonConstructor]
    public Responses (){}
    
 
    public Responses(string? message, TData data, int code = 200)
    {
        Code = code;
        Message = message;
        Data = data;
    }

    public static Responses<TData> Error(string message, TData data, int code = 400)
        => new Responses<TData>(message, data, default);
            
    public int Code { get; set; }
    public string? Message { get; set; }
    public  TData? Data { get; set; }


    [JsonIgnore] public bool ISsucess => Code is >= 200 and <= 299;
    [JsonIgnore] public bool IsError => Code is >= 400 and <= 599;
}