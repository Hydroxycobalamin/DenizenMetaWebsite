﻿using SharpDenizenTools.MetaObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DenizenMetaWebsite.MetaObjects {
    public class WebsiteMetaScript : WebsiteMetaObject<MetaScript> {
        public override void LoadHTML() {
            HtmlContent = HTML_PREFIX;
            string aID = Util.EscapeForHTML(Object.CleanName);
            HtmlContent += TableLine("primary", "Name", $"<a id=\"{aID}\" href=\"#{aID}\" onclick=\"doFlashFor('{aID}')\"><span class=\"doc_name\">{Util.EscapeForHTML(Object.Name)}</span></a>", false);
            HtmlContent += TableLine("default", "Description", Object.Description, true);
            HtmlContent += TableLine("default", "Download", Object.Download, true);
            AddHtmlEndParts();
        }

        public override string GroupingString => Object.Group;
    }
}
