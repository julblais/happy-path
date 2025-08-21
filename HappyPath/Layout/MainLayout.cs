using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace HappyPath.Layout;

public partial class MainLayout : LayoutComponentBase
{
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(MainLayout))]
    public MainLayout() { }
}