﻿using ImplicitNullability.Plugin.Highlighting;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.Tree;
using ReSharperExtensionsShared.Highlighting;

[assembly: RegisterConfigurableSeverity(
    ImplicitNotNullResultOverridesUnknownBaseMemberNullabilityHighlighting.SeverityId,
    CompoundItemName: null,
    Group: HighlightingGroupIds.CodeSmell,
    Title: ImplicitNotNullResultOverridesUnknownBaseMemberNullabilityHighlighting.Message,
    Description: ImplicitNotNullResultOverridesUnknownBaseMemberNullabilityHighlighting.Description,
    DefaultSeverity: Severity.HINT
#if RESHARPER20162
    , SolutionAnalysisRequired: false
#endif
    , AlternativeIDs = "ImplicitNotNullResultOverridesUnknownExternalMember"
)]

namespace ImplicitNullability.Plugin.Highlighting
{
    [ConfigurableSeverityHighlighting(
        SeverityId,
        "CSHARP",
        OverlapResolve = OverlapResolveKind.WARNING,
        ToolTipFormatString = Message)]
    public class ImplicitNotNullResultOverridesUnknownBaseMemberNullabilityHighlighting : SimpleTreeNodeHighlightingBase<ITreeNode>
    {
        public const string SeverityId = "ImplicitNotNullResultOverridesUnknownBaseMemberNullability";

        public const string Message = "Implicit NotNull result or out parameter overrides unknown nullability of base member, " +
                                      "nullability should be explicit";

        public const string Description =
            "Warns about implicit [NotNull] results or out parameters that override a base class/interface member " +
            "which has no corresponding nullability annotations (neither by attributes nor by external XML annotations). " +
            "As the the base member's nullability is unknown, we implicitly convert a possibly [CanBeNull] result to [NotNull] if " +
            "the base calls' return value is returned. " +
            "It's better to explicitly annotate these occurrences with [NotNull] or [CanBeNull] after manually checking " +
            "the nullability of the base member. " +
            SharedHighlightingTexts.NeedsSettingNoteText;

        public ImplicitNotNullResultOverridesUnknownBaseMemberNullabilityHighlighting(ITreeNode treeNode)
            : base(treeNode, Message)
        {
        }
    }
}
