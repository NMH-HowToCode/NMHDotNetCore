// See https://aka.ms/new-console-template for more information

using NMHDotNetCore.ConsoleApplication.AdoDotNetExamples;
using NMHDotNetCore.ConsoleApplication.DapperExamples;
using NMHDotNetCore.ConsoleApplication.EFCoreExamples;



//new AdoDotNetExample().Read();

//new AdoDotNetExample().Create("Internet", "Ryan", "How to use Internet");

//new AdoDotNetExample().Delete(1005);

//new AdoDotNetExample().Update(1006, "Local", "John", "How to update");

//new AdoDotNetExample().Edit(1006);

//new DapperExample().Run();

new EFCoreExample().Run();

Console.ReadKey();
