using System;
using System.Collections.Generic;

namespace Demo;

public partial class Tool
{
    public int ToolId { get; set; }

    public string? ToolType { get; set; }

    public double? Price { get; set; }

    public int? BattV { get; set; }

    public string? Brand { get; set; }

    public override string ToString()
    {
        return $"ToolId: {ToolId}\nToolType: {ToolType}\nPrice: {Price}\nBattV: {BattV}\nBrand: {Brand}\n";
    }
}
