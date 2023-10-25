using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            IFilter filter = new FilterBlurConvolution();
            IFilter filter2 = new FilterGreyscale();

            IPipe pipe0 = new PipeNull();
            IPipe pipe = new PipeSerial(filter2, pipe0);
            IPipe pipe2 = new PipeSerial(filter, pipe);

            IPicture result = pipe2.Send(picture);
            provider.SavePicture(result, "@beer_whith_filter_jpg");

        }
    }
}



