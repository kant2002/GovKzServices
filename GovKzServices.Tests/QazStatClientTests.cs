namespace GovKzServices.Tests;

public class QazStatClientTests
{
    [Fact]
    public async Task BinCheckSuccess()
    {
        var httpClient = new HttpClient(new FileHttpHandler("BinCheckSuccess.json"));
        var client = new QazStatClient(httpClient);
        var result = await client.GetJuridicalAsync(120200003550, "ru");

        Assert.NotNull(result);
        Assert.True(result.Success);
        Assert.Null(result.Description);
        Assert.NotNull(result.Obj);

        Assert.Equal("1202XXX03550", result.Obj.Bin);
        Assert.Equal("ТОО XXXXXX", result.Obj.Name);
        Assert.Equal("96090", result.Obj.OkedCode);
        Assert.Equal("Предоставление прочих индивидуальных услуг, не включенных в другие группировки", result.Obj.OkedName);
        Assert.Equal("105", result.Obj.KrpCode);
        Assert.Equal("Малые предприятия (<= 5)", result.Obj.KrpName);
        Assert.Equal("105", result.Obj.KrpBfCode);
        Assert.Equal("Малые предприятия (<= 5)", result.Obj.KrpBfName);
        Assert.Equal("1122", result.Obj.KseCode);
        Assert.Equal("Национальные частные нефинансовые корпорации – ОПП", result.Obj.KseName);
        Assert.Equal("19", result.Obj.KfsCode);
        Assert.Equal("Собственность предприятий без государственного и  иностранного участия", result.Obj.KfsName);
        Assert.Equal("751110000", result.Obj.KatoCode);
        Assert.Equal(268023, result.Obj.KatoId);
        Assert.Equal("Г.АЛМАТЫ, АЛМАЛИНСКИЙ РАЙОН, улица Жамбыла, дом XXXX", result.Obj.KatoAddress);
        Assert.Equal("АБРАМС XXXX YYYY", result.Obj.Fio);
    }
}