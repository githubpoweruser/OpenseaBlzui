using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OpenseaBlzui.Helper.Interface;
using OpenseaBlzui.Models;

namespace OpenseaBlzui.Pages.Components
{
    public partial class MenuFirstPage
    {
        [Inject] public IHttpClientHelper HttpClientHelper { get; set; }
        private HttpRequestInfo httpRequestInfo; //Http响应所需资料
        private List<string> imgs = new(); //数据库图片地址
        private readonly string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\images"}"; //当前项目地址
        private readonly List<string> imgList = new(); //轮播图相对地址
        private List<DetailsInfo> detailsInfos = new();
        private ArticleAndImgInfo articleAndImgInfos = new()
        {
            ArticleInfos = new List<ArticleInfo>(),
            ImgInfos = new List<ImgInfo>(),
            MenuInfo = new MenuInfo()
        };

        protected async override Task OnInitializedAsync()
        {
            await LoadImg();
            await GetDetailsInfo();
            await GetArticleAndImgInfo();
        }

        /// <summary>
        /// 加载轮播图片资料
        /// </summary>
        /// <returns></returns>
        public async Task LoadImg()
        {
            await GetCarouselImg();
            LoadFiles();
        }

        /// <summary>
        /// 获取数据库轮播资料
        /// </summary>
        /// <returns></returns>
        public async Task GetCarouselImg()
        {
            httpRequestInfo = new HttpRequestInfo()
            {
                Route = "api/basicInfo/getCarouselImg",
                Flag = "OpenseaAPI",
                Content = "",
                MethodRequst = HttpMethod.Get
            };
            string requst = await HttpClientHelper.HttpClientSendAsync(httpRequestInfo);
            var data = JsonConvert.DeserializeObject<List<CarouselImg>>(requst);
            imgs = data?.Select(x => x.ImgAddr).ToList();
        }

        /// <summary>
        /// 加载文件资料
        /// </summary>
        public void LoadFiles()
        {
            var files = Directory.GetFiles(path);
            string temp;
            foreach (var file in files)
            {
                temp = "/images/" + Path.GetFileName(file);

                //筛选 对比数据库存储资料
                if (imgs.Contains(temp))
                {
                    imgList.Add(temp);
                }
            }
        }

        /// <summary>
        /// 获取详情资料
        /// </summary>
        /// <returns></returns>
        public async Task GetDetailsInfo()
        {
            httpRequestInfo = new HttpRequestInfo()
            {
                Route = "api/basicInfo/getDetailsInfo",
                Flag = "OpenseaAPI",
                Content = "",
                MethodRequst = HttpMethod.Get
            };
            string requst = await HttpClientHelper.HttpClientSendAsync(httpRequestInfo);
            detailsInfos = JsonConvert.DeserializeObject<List<DetailsInfo>>(requst);
        }

        public async Task GetArticleAndImgInfo()
        {
            httpRequestInfo = new HttpRequestInfo()
            {
                Route = "api/basicInfo/getArticleAndImgInfo?menuNumber=" + 1,
                Flag = "OpenseaAPI",
                Content = "",
                MethodRequst = HttpMethod.Get
            };
            string requst = await HttpClientHelper.HttpClientSendAsync(httpRequestInfo);
            articleAndImgInfos = JsonConvert.DeserializeObject<ArticleAndImgInfo>(requst);
        }
    }
}
