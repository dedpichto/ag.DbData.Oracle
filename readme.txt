
// add section to settings file (optional)
{
  "DbDataSettings": {
    "AllowExceptionLogging": false // default is "true" 
  }
}

***************************************************************************************************

// add appropriate usings
using ag.DbData.Oracle.Extensions;
using ag.DbData.Oracle.Factories;

***************************************************************************************************

// register services with extension method

		// ...
		services.AddAgOracle();
		// or
		services.AddAgOracle(config.GetSection("DbDataSettings"));
		// or
		services.AddAgOracle(opts =>
        {
            opts.AllowExceptionLogging = false; 
        });

***************************************************************************************************

// inject IOracleDbDataFactory into your classes

        private readonly IOracleDbDataFactory _oracleFactory;

        public MyClass(IOracleDbDataFactory oracleFactory)
        {
            _oracleFactory = oracleFactory;
        }

***************************************************************************************************

// OracleDbDataObject implements IDisposable interface, so use it into 'using' directive

        using (var oracleDbData = _oracleFactory.Create(YOUR_CONNECTION_STRING))
        {
            using (var t = oracleDbData.FillDataTable("SELECT * FROM YOUR_TABLE"))
            {
                foreach (DataRow r in t.Rows)
                {
                    Console.WriteLine(r[0]);
                }
            }
        }

***************************************************************************************************