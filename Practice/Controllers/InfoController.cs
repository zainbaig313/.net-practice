using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/info")]

public class InfoController : ControllerBase
{
    private static List<Info> Information = new List<Info>();



    [HttpGet]
    public ActionResult<IEnumerable<Info>> GetAll()
    {
        return Information;
    }

    [HttpGet("{RegNo}")]
    public ActionResult<Info> GetByRegNo(int RegNo)
    {
        var info = Information.FirstOrDefault(i => i.RegNo == RegNo);
        if (info == null) return NotFound();

        return Ok(info);
    }

    [HttpPost]
    public ActionResult<Info> Create([FromBody] Info NewInformation)
    {
        Information.Add(NewInformation);
        return Ok(NewInformation);
    }

    [HttpPut("{RegNo}")]
    public IActionResult Update(int RegNo ,[FromBody] Info updateinfo)
    {
        var info = Information.FirstOrDefault(i => i.RegNo == RegNo);
        if (info == null) return NotFound();

        info.RegNo = updateinfo.RegNo;
        info.Name = updateinfo.Name;
        info.Class = updateinfo.Class;

        return Ok();
    }


    [HttpDelete("{RegNo}")]
    public IActionResult Delete(int RegNo)
    {
        var deleteInfo = Information.FirstOrDefault(i => i.RegNo == RegNo);
        if (deleteInfo == null) return NotFound();
        Information.Remove(deleteInfo);
        return Ok();
    }


}