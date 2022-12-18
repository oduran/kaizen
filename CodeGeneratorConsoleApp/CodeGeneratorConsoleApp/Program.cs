// See https://aka.ms/new-console-template for more information
using CodeGeneratorConsoleApp;

List<string> uniqueCodes = new List<string>();
int codeSize = 8;

// create 10billion unique code with determined algorithm
while (uniqueCodes.Count != 10000000)
{
    //Generate unique string by time tick
    var code = CodeGenerator.GenerateUniqueString(codeSize);
    if (!CodeGenerator.IsValidString(code))
    {
        continue;
    }
    Console.WriteLine(code);
    uniqueCodes.Add(code);
}
