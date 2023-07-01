using Task3.UI.Commands;

namespace Task3.UI.ViewModels.Buttons;

internal sealed class CellButtonViewModel
{
    // ReSharper disable once UnusedMember.Global
    public bool CanSelect { get; set; } = true;

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public ClickOnButtonCommand ClickOnButton { get; }

    // ReSharper disable once MemberCanBePrivate.Global
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public ClickOnButtonCommand RightClickOnButton { get; }

    public CellButtonViewModel(ClickOnButtonCommand clickOnCellCommand, ClickOnButtonCommand rightClickOnCellCommand)
    {
        ClickOnButton = clickOnCellCommand;
        RightClickOnButton = rightClickOnCellCommand;
    }
}