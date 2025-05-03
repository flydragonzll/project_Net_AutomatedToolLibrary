using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright.Models.Step
{
    public class _PageMethod_GetByRole
    {
        [JsonPropertyName("_ariaRole")]
        public _PageMethod_GetByRole_AriaRole _ariaRole { get; set; }
        [JsonPropertyName("_pageGetByRoleOptions")]
        public _PageMethod_GetByRole_PageGetByRoleOptions _pageGetByRoleOptions { get; set; }
        [JsonPropertyName("_ret_ILocator")]
        public ILocator _ret_ILocator { get; set; }
    }
    public enum _PageMethod_GetByRole_AriaRole
    {
        [EnumMember(Value = "alert")]
        Alert,
        [EnumMember(Value = "alertdialog")]
        Alertdialog,
        [EnumMember(Value = "application")]
        Application,
        [EnumMember(Value = "article")]
        Article,
        [EnumMember(Value = "banner")]
        Banner,
        [EnumMember(Value = "blockquote")]
        Blockquote,
        [EnumMember(Value = "button")]
        Button,
        [EnumMember(Value = "caption")]
        Caption,
        [EnumMember(Value = "cell")]
        Cell,
        [EnumMember(Value = "checkbox")]
        Checkbox,
        [EnumMember(Value = "code")]
        Code,
        [EnumMember(Value = "columnheader")]
        Columnheader,
        [EnumMember(Value = "combobox")]
        Combobox,
        [EnumMember(Value = "complementary")]
        Complementary,
        [EnumMember(Value = "contentinfo")]
        Contentinfo,
        [EnumMember(Value = "definition")]
        Definition,
        [EnumMember(Value = "deletion")]
        Deletion,
        [EnumMember(Value = "dialog")]
        Dialog,
        [EnumMember(Value = "directory")]
        Directory,
        [EnumMember(Value = "document")]
        Document,
        [EnumMember(Value = "emphasis")]
        Emphasis,
        [EnumMember(Value = "feed")]
        Feed,
        [EnumMember(Value = "figure")]
        Figure,
        [EnumMember(Value = "form")]
        Form,
        [EnumMember(Value = "generic")]
        Generic,
        [EnumMember(Value = "grid")]
        Grid,
        [EnumMember(Value = "gridcell")]
        Gridcell,
        [EnumMember(Value = "group")]
        Group,
        [EnumMember(Value = "heading")]
        Heading,
        [EnumMember(Value = "img")]
        Img,
        [EnumMember(Value = "insertion")]
        Insertion,
        [EnumMember(Value = "link")]
        Link,
        [EnumMember(Value = "list")]
        List,
        [EnumMember(Value = "listbox")]
        Listbox,
        [EnumMember(Value = "listitem")]
        Listitem,
        [EnumMember(Value = "log")]
        Log,
        [EnumMember(Value = "main")]
        Main,
        [EnumMember(Value = "marquee")]
        Marquee,
        [EnumMember(Value = "math")]
        Math,
        [EnumMember(Value = "meter")]
        Meter,
        [EnumMember(Value = "menu")]
        Menu,
        [EnumMember(Value = "menubar")]
        Menubar,
        [EnumMember(Value = "menuitem")]
        Menuitem,
        [EnumMember(Value = "menuitemcheckbox")]
        Menuitemcheckbox,
        [EnumMember(Value = "menuitemradio")]
        Menuitemradio,
        [EnumMember(Value = "navigation")]
        Navigation,
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "note")]
        Note,
        [EnumMember(Value = "option")]
        Option,
        [EnumMember(Value = "paragraph")]
        Paragraph,
        [EnumMember(Value = "presentation")]
        Presentation,
        [EnumMember(Value = "progressbar")]
        Progressbar,
        [EnumMember(Value = "radio")]
        Radio,
        [EnumMember(Value = "radiogroup")]
        Radiogroup,
        [EnumMember(Value = "region")]
        Region,
        [EnumMember(Value = "row")]
        Row,
        [EnumMember(Value = "rowgroup")]
        Rowgroup,
        [EnumMember(Value = "rowheader")]
        Rowheader,
        [EnumMember(Value = "scrollbar")]
        Scrollbar,
        [EnumMember(Value = "search")]
        Search,
        [EnumMember(Value = "searchbox")]
        Searchbox,
        [EnumMember(Value = "separator")]
        Separator,
        [EnumMember(Value = "slider")]
        Slider,
        [EnumMember(Value = "spinbutton")]
        Spinbutton,
        [EnumMember(Value = "status")]
        Status,
        [EnumMember(Value = "strong")]
        Strong,
        [EnumMember(Value = "subscript")]
        Subscript,
        [EnumMember(Value = "superscript")]
        Superscript,
        [EnumMember(Value = "switch")]
        Switch,
        [EnumMember(Value = "tab")]
        Tab,
        [EnumMember(Value = "table")]
        Table,
        [EnumMember(Value = "tablist")]
        Tablist,
        [EnumMember(Value = "tabpanel")]
        Tabpanel,
        [EnumMember(Value = "term")]
        Term,
        [EnumMember(Value = "textbox")]
        Textbox,
        [EnumMember(Value = "time")]
        Time,
        [EnumMember(Value = "timer")]
        Timer,
        [EnumMember(Value = "toolbar")]
        Toolbar,
        [EnumMember(Value = "tooltip")]
        Tooltip,
        [EnumMember(Value = "tree")]
        Tree,
        [EnumMember(Value = "treegrid")]
        Treegrid,
        [EnumMember(Value = "treeitem")]
        Treeitem,
    }
    public class _PageMethod_GetByRole_PageGetByRoleOptions
    {
        /// <summary>
        /// <para>
        /// An attribute that is usually set by <c>aria-checked</c> or native <c>&lt;input type=checkbox&gt;</c>
        /// controls.
        /// </para>
        /// <para>Learn more about <a href="https://www.w3.org/TR/wai-aria-1.2/#aria-checked"><c>aria-checked</c></a>.</para>
        /// </summary>
        [JsonPropertyName("checked")]
        public bool? Checked { get; set; }

        /// <summary>
        /// <para>An attribute that is usually set by <c>aria-disabled</c> or <c>disabled</c>.</para>
        /// <para>
        /// Unlike most other attributes, <c>disabled</c> is inherited through the DOM hierarchy.
        /// Learn more about <a href="https://www.w3.org/TR/wai-aria-1.2/#aria-disabled"><c>aria-disabled</c></a>.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Unlike most other attributes, <c>disabled</c> is inherited through the DOM hierarchy.
        /// Learn more about <a href="https://www.w3.org/TR/wai-aria-1.2/#aria-disabled"><c>aria-disabled</c></a>.
        ///
        /// </para>
        /// </remarks>
        [JsonPropertyName("disabled")]
        public bool? Disabled { get; set; }

        /// <summary>
        /// <para>
        /// Whether <see cref="IPage.GetByRole"/> is matched exactly: case-sensitive and whole-string.
        /// Defaults to false. Ignored when <see cref="IPage.GetByRole"/> is a regular expression.
        /// Note that exact match still trims whitespace.
        /// </para>
        /// </summary>
        [JsonPropertyName("exact")]
        public bool? Exact { get; set; }

        /// <summary>
        /// <para>An attribute that is usually set by <c>aria-expanded</c>.</para>
        /// <para>Learn more about <a href="https://www.w3.org/TR/wai-aria-1.2/#aria-expanded"><c>aria-expanded</c></a>.</para>
        /// </summary>
        [JsonPropertyName("expanded")]
        public bool? Expanded { get; set; }

        /// <summary>
        /// <para>
        /// Option that controls whether hidden elements are matched. By default, only non-hidden
        /// elements, as <a href="https://www.w3.org/TR/wai-aria-1.2/#tree_exclusion">defined
        /// by ARIA</a>, are matched by role selector.
        /// </para>
        /// <para>Learn more about <a href="https://www.w3.org/TR/wai-aria-1.2/#aria-hidden"><c>aria-hidden</c></a>.</para>
        /// </summary>
        [JsonPropertyName("includeHidden")]
        public bool? IncludeHidden { get; set; }

        /// <summary>
        /// <para>
        /// A number attribute that is usually present for roles <c>heading</c>, <c>listitem</c>,
        /// <c>row</c>, <c>treeitem</c>, with default values for <c>&lt;h1&gt;-&lt;h6&gt;</c>
        /// elements.
        /// </para>
        /// <para>Learn more about <a href="https://www.w3.org/TR/wai-aria-1.2/#aria-level"><c>aria-level</c></a>.</para>
        /// </summary>
        [JsonPropertyName("level")]
        public int? Level { get; set; }

        /// <summary>
        /// <para>
        /// Option to match the <a href="https://w3c.github.io/accname/#dfn-accessible-name">accessible
        /// name</a>. By default, matching is case-insensitive and searches for a substring,
        /// use <see cref="IPage.GetByRole"/> to control this behavior.
        /// </para>
        /// <para>
        /// Learn more about <a href="https://w3c.github.io/accname/#dfn-accessible-name">accessible
        /// name</a>.
        /// </para>
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// <para>
        /// Option to match the <a href="https://w3c.github.io/accname/#dfn-accessible-name">accessible
        /// name</a>. By default, matching is case-insensitive and searches for a substring,
        /// use <see cref="IPage.GetByRole"/> to control this behavior.
        /// </para>
        /// <para>
        /// Learn more about <a href="https://w3c.github.io/accname/#dfn-accessible-name">accessible
        /// name</a>.
        /// </para>
        /// </summary>
        [JsonPropertyName("nameRegex")]
        public Regex? NameRegex { get; set; }

        /// <summary>
        /// <para>
        /// Option to match the <a href="https://w3c.github.io/accname/#dfn-accessible-name">accessible
        /// name</a>. By default, matching is case-insensitive and searches for a substring,
        /// use <see cref="IPage.GetByRole"/> to control this behavior.
        /// </para>
        /// <para>
        /// Learn more about <a href="https://w3c.github.io/accname/#dfn-accessible-name">accessible
        /// name</a>.
        /// </para>
        /// </summary>
        [JsonPropertyName("nameString")]
        public string? NameString { get; set; }

        /// <summary>
        /// <para>An attribute that is usually set by <c>aria-pressed</c>.</para>
        /// <para>Learn more about <a href="https://www.w3.org/TR/wai-aria-1.2/#aria-pressed"><c>aria-pressed</c></a>.</para>
        /// </summary>
        [JsonPropertyName("pressed")]
        public bool? Pressed { get; set; }

        /// <summary>
        /// <para>An attribute that is usually set by <c>aria-selected</c>.</para>
        /// <para>Learn more about <a href="https://www.w3.org/TR/wai-aria-1.2/#aria-selected"><c>aria-selected</c></a>.</para>
        /// </summary>
        [JsonPropertyName("selected")]
        public bool? Selected { get; set; }
    }
}
