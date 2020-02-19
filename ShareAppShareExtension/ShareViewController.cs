using System;
using System.Collections.Generic;
using CoreFoundation;
using Foundation;
using MobileCoreServices;
using Newtonsoft.Json;
using Social;
using UIKit;

namespace ShareAppShareExtension
{
    public partial class ShareViewController : SLComposeServiceViewController
    {
        List<string> PathList;
        public ShareViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            NSExtensionItem item = ExtensionContext.InputItems[0];
            if (item.Attachments.Length <= 10)
            {
                PathList = new List<string>();

                foreach (NSItemProvider itemProvider in item.Attachments)
                {
                    var type = itemProvider.Description.Split('"');
                    if (itemProvider.HasItemConformingTo(type[1]))
                    {
                        itemProvider.LoadItem(type[1], null, (url, error) =>
                        {
                            if (url != null)
                            {
                                var a = ((NSUrl)(url));
                                PathList.Add(a.AbsoluteString);


                            }
                        });
                    }
                }
            }
        }

        public override bool ShouldInteractWithUrl(UITextView textView, NSUrl url, NSRange characterRange, UITextItemInteraction interaction)
        {
            return base.ShouldInteractWithUrl(textView, url, characterRange, interaction);
        }

        public override bool IsContentValid()
        {
            // Do validation of contentText and/or NSExtensionContext attachments here
            return true;
        }

        public override void DidSelectPost()
        {
            // This is called after the user selects Post. Do the upload of contentText and/or NSExtensionContext attachments.

            // Inform the host that we're done, so it un-blocks its UI. Note: Alternatively you could call super's -didSelectPost, which will similarly complete the extension context.
        }

        public override void PresentationAnimationDidFinish()
        {
            base.PresentationAnimationDidFinish();
        }

        public override SLComposeSheetConfigurationItem[] GetConfigurationItems()
        {
            if(PathList.Count == ExtensionContext.InputItems[0].Attachments.Length)
            {
                string path = "";
                path = JsonConvert.SerializeObject(PathList);
                var defs = new NSUserDefaults("group.com.shareapp.ios", NSUserDefaultsType.SuiteName);
                defs.SetString(path, "FilePathList");
                defs.Synchronize();

                
                ExtensionContext.CompleteRequest(new NSExtensionItem[0], null);
                UIApplication.SharedApplication.OpenUrl(new NSUrl("com.shareapp.test://"));
                
            }

            // To add configuration options via table cells at the bottom of the sheet, return an array of SLComposeSheetConfigurationItem here.
            return new SLComposeSheetConfigurationItem[0];
        }
    }
}
