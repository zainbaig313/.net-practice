using System.Text.Json;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/s")]

public class SerializationContoller : ControllerBase
{

    Person samplePerson = new Person
    {
        UserName = "zain" ,
        UserAge = 26
    };

    [HttpGet]
    public ActionResult GetReturn()
    {
        return Ok(samplePerson);
    }

    [HttpGet("manual-json")]
    public IActionResult GetManualJson()
    {
        var jsonstring = JsonSerializer.Serialize(samplePerson);
        return Content(jsonstring ,  "application/json");
    }
    [HttpGet("custom-json")]
    public IActionResult GetCustomJson()
    {
        var customjson = new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower  
        };
        var jsonstring = JsonSerializer.Serialize(samplePerson, customjson);
        return Content(jsonstring ,  "application/json");
    }
    [HttpGet("xml")] 
    public IActionResult GetXml()
    {
        var xmlSerializer = new XmlSerializer(typeof(Person));

        var stringwriter = new StringWriter();

        xmlSerializer.Serialize(stringwriter , samplePerson);

        var xmloutput = stringwriter.ToString();

        return Content(xmloutput, "application/xml");
    }

}