using System;
using Xamarin.Forms;

namespace MediaPlayerElementSample
{
    public class CarouselItemsDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var model = item as CarouselModel;
            if (model.ModelType == "Video")
                return new VideoItemDataTemplate();
            else
                return new NormalItemDataTemplate();
        }
    }
}
