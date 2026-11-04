Console.WriteLine("========== Employee Records ==========");


using StreamReader reader = new StreamReader("")

List<string[]> invalidEnteries = new();

decimal salary = 0;


Console.WriteLine("Valid enteries");
foreach (var item in data)
{
    string[] employeedata = item.Split(",", StringSplitOptions.TrimEntries);
    if (employeedata.Length == 4)
    {
        
        if(decimal.TryParse(employeedata[3],out decimal sal))
        {
            Console.WriteLine($"id =  {employeedata[0]} | name = {employeedata[1]} role = {employeedata[2]} salary = {employeedata[3]}");
            salary += sal;
        }
        else
        {
            invalidEnteries.Add(employeedata);
        }
    }
    else
    {
        invalidEnteries.Add(employeedata);
    }

}

Console.WriteLine($"\n invalid record");
foreach (var item in invalidEnteries)
{
    foreach (var entry in item)
    {
        Console.Write(entry + " ");
    }

    Console.WriteLine();

}
Console.WriteLine($"\nvalid total salary  : {salary}");