namespace Resources;

public class IncomeSupportParameterRepository(DatabaseContext databaseContext) : IIncomeSupportParameterRepository
{
    public decimal GetCOLA(DateTime effectiveDate, decimal cap)
    {
        var queryResults = databaseContext.Vsd_IncomeSupportParameterSet
            .Where(x => x.Vsd_Type == Vsd_IncomeSupportParameter_Vsd_Type.Cola)
            .Where(x => x.Vsd_EffectiveDate >= effectiveDate.ToLocalTime().Date)
            .Where(x => x.StateCode == (Vsd_IncomeSupportParameter_StateCode)StateCode.Active)
            .Where(x => x.StatusCode == (Vsd_IncomeSupportParameter_StatusCode)StatusCode.Active)
            .Where(x => x.Vsd_IncomeSupportParameterValidated == Vsd_YesNo.Yes)
            .ToList();

        if (queryResults.Count > 0) 
        {
            var colaValue = cap;

            // NOTE this below line would probably work but in an effort to cut corners, use the below code which is a tested version that works
            //return queryResults.Sum(x => (colaValue += colaValue * (decimal)x.Vsd_Value) / 100);

            foreach (var  ent in queryResults)
            {
                colaValue = colaValue + ((colaValue * (decimal)ent.Vsd_Value) / 100);
            }
            return colaValue;
        }
        else
        {
            return cap;
        }
    }
}
