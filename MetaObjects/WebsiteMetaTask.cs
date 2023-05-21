using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DenizenMetaWebsite.Highlighters;
using FreneticUtilities.FreneticExtensions;
using SharpDenizenTools.MetaObjects;

namespace DenizenMetaWebsite.MetaObjects {
    public class WebsiteMetaTask : WebsiteMetaObject<MetaTask> {
        public override void LoadHTML() {
            HtmlContent = HTML_PREFIX;
            string aID = Util.EscapeForHTML(Object.CleanName);
            HtmlContent += TableLine("primary", "Name", $"<a id=\"{aID}\" href=\"#{aID}\" onclick=\"doFlashFor('{aID}')\"><span class=\"doc_name\">{Util.EscapeForHTML(Object.MechName)}</span></a>", false);
            HtmlContent += TableLine("default", "Input", Object.Input, true);
            HtmlContent += TableLine("default", "Description", Object.Description, true);
            foreach (string usage in Object.Usages) {
                HtmlContent += TableLine("default", "Usage Example", ScriptHighlighter.Highlight("#" + usage), false);
            }
            if (Object.MustInjected) {
                HtmlContent += TableLine("default", "Injected", "True - This task must be injected.", true);
            }
            AddHtmlEndParts();
        }

        public override string GroupingString => Object.Name + " Tasks";
    }
}
