/*************************************************
**
** You're viewing a file in the SMAPI mod dump, which contains a copy of every open-source SMAPI mod
** for queries and analysis.
**
** This is *not* the original file, and not necessarily the latest version.
** Source repository: https://github.com/Pathoschild/StardewMods
**
*************************************************/

using System.Diagnostics.CodeAnalysis;
using ContentPatcher.Framework.Lexing.LexTokens;
using StardewModdingAPI;

namespace ContentPatcher.Framework.Migrations
{
    /// <summary>Migrate patches to format version 1.9.</summary>
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Named for clarity.")]
    internal class Migration_1_9 : BaseMigration
    {
        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        public Migration_1_9()
            : base(new SemanticVersion(1, 9, 0)) { }

        /// <inheritdoc />
        public override bool TryMigrate(ILexToken lexToken, out string error)
        {
            if (!base.TryMigrate(lexToken, out error))
                return false;

            // 1.9 adds mod tokens
            if (lexToken is LexTokenToken token && token.Name.Contains(InternalConstants.ModTokenSeparator))
            {
                error = this.GetNounPhraseError($"using custom mod-provided tokens like '{lexToken}'");
                return false;
            }

            return true;
        }
    }
}
