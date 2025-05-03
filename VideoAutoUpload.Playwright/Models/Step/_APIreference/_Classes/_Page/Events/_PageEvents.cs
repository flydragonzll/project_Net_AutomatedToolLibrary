using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VideoAutoUpload.Playwright.Models.Step
{
    public class _PageEvents
    {
        [JsonPropertyName("_pageEvent_EventClose")]
        public _PageEvent_EventClose _pageEvent_EventClose { get; set; } = new _PageEvent_EventClose();
        [JsonPropertyName("_pageEvent_EventConsole")]
        public _PageEvent_EventConsole _pageEvent_EventConsole { get; set; } = new _PageEvent_EventConsole();
        [JsonPropertyName("_pageEvent_EventCrash")]
        public _PageEvent_EventCrash _pageEvent_EventCrash { get; set; } = new _PageEvent_EventCrash();
        [JsonPropertyName("_pageEvent_EventDialog")]
        public _PageEvent_EventDialog _pageEvent_EventDialog { get; set; } = new _PageEvent_EventDialog();
        [JsonPropertyName("_pageEvent_EventDOMContentLoaded")]
        public _PageEvent_EventDOMContentLoaded _pageEvent_EventDOMContentLoaded { get; set; } = new _PageEvent_EventDOMContentLoaded();
        [JsonPropertyName("_pageEvent_EventDownload")]
        public _PageEvent_EventDownload _pageEvent_EventDownload { get; set; } = new _PageEvent_EventDownload();
        [JsonPropertyName("_pageEvent_EventFileChooser")]
        public _PageEvent_EventFileChooser _pageEvent_EventFileChooser { get; set; } = new _PageEvent_EventFileChooser();
        [JsonPropertyName("_pageEvent_EventFrameAttached")]
        public _PageEvent_EventFrameAttached _pageEvent_EventFrameAttached { get; set; } = new _PageEvent_EventFrameAttached();
        [JsonPropertyName("_pageEvent_EventFrameDetached")]
        public _PageEvent_EventFrameDetached _pageEvent_EventFrameDetached { get; set; } = new _PageEvent_EventFrameDetached();
        [JsonPropertyName("_pageEvent_EventFrameNavigated")]
        public _PageEvent_EventFrameNavigated _pageEvent_EventFrameNavigated { get; set; } = new _PageEvent_EventFrameNavigated();
        [JsonPropertyName("_pageEvent_EventLoad")]
        public _PageEvent_EventLoad _pageEvent_EventLoad { get; set; } = new _PageEvent_EventLoad();
        [JsonPropertyName("_pageEvent_EventPageError")]
        public _PageEvent_EventPageError _pageEvent_EventPageError { get; set; } = new _PageEvent_EventPageError();
        [JsonPropertyName("_pageEvent_EventPopup")]
        public _PageEvent_EventPopup _pageEvent_EventPopup { get; set; } = new _PageEvent_EventPopup();
        [JsonPropertyName("_pageEvent_EventRequest")]
        public _PageEvent_EventRequest _pageEvent_EventRequest { get; set; } = new _PageEvent_EventRequest();
        [JsonPropertyName("_pageEvent_EventRequestFailed")]
        public _PageEvent_EventRequestFailed _pageEvent_EventRequestFailed { get; set; } = new _PageEvent_EventRequestFailed();
        [JsonPropertyName("_pageEvent_EventRequestFinished")]
        public _PageEvent_EventRequestFinished _pageEvent_EventRequestFinished { get; set; } = new _PageEvent_EventRequestFinished();
        [JsonPropertyName("_pageEvent_EventResponse")]
        public _PageEvent_EventResponse _pageEvent_EventResponse { get; set; } = new _PageEvent_EventResponse();
        [JsonPropertyName("_pageEvent_EventWebSocket")]
        public _PageEvent_EventWebSocket _pageEvent_EventWebSocket { get; set; } = new _PageEvent_EventWebSocket();
        [JsonPropertyName("_pageEvent_EventWorker")]
        public _PageEvent_EventWorker _pageEvent_EventWorker { get; set; } = new _PageEvent_EventWorker();
    }
}