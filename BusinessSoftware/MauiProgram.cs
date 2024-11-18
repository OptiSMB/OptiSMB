using BusinessSoftware.Security;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace BusinessSoftware
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string folderPath = @"C:\Users\Ahar\Desktop\PersonalCode\BusinessSoftware\BusinessSoftware\Pages\";  // Set your folder path
            var files = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                if (!CheckSecurityDependencyInFile(file))
                {
                    Environment.Exit(0);
                }
            }
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).RegisterServices();
            ;

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IBusinessSecurity, SecurityImpementation>();

            // More services registered here.

            return mauiAppBuilder;
        }
        private static bool CheckSecurityDependencyInFile(string filePath)
        {
            string code = File.ReadAllText(filePath);

            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = syntaxTree.GetRoot();

            // Find all classes
            var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            foreach (var classDeclaration in classes)
            {
                // Check if the class has a constructor that takes ISecurity as a dependency
                var constructor = classDeclaration.Members
                                                  .OfType<ConstructorDeclarationSyntax>()
                                                  .FirstOrDefault();

                if (constructor != null)
                {
                    var parameters = constructor.ParameterList.Parameters;
                    bool hasSecurityDependency = parameters
                                                  .Any(p => p.Type?.ToString() == "IBusinessSecurity");

                    if (hasSecurityDependency)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
