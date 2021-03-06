using CalamariBlog.Services.CMS.Mappers.Contracts;
using CalamariBlog.Infrastructure.Configuration;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models;
using CalamariBlog.Models.CMS;
using Microsoft.Extensions.Options;
using System.Linq;
using CalamariBlog.Infrastructure.Repositories.SquidexRepo.Models.Pages;
using CalamariBlog.Models.CMS.Pages;

namespace CalamariBlog.Services.CMS.Mappers
{
    public class CMSMapper : BaseMapper, ICMSMapper
    {
        public CMSMapper(IOptions<SquidexSettings> config) : base(config) { }

        public BlogPost MapToBlogPost(BlogPostEntity model, AuthorEntity author)
        {
            var result = new BlogPost()
            {
                Id = model.Id,
                Slug = model.Data.Slug,
                PublishedDate = model.Data.PublishDate,
                ImageHeaderUrl = ResolveAssetURL(model.Data.ImageHeader.First()),
                Title = model.Data.Title,
                Tags = model.Data.Tags,
                Subtitle = model.Data.SubTitle,
                BodyHtml = model.Data.BodyHtml,
                MetaDescription = model.Data.MetaDescription,
                Author = new Author()
                {
                    Name = author.Data.Name,
                    Link = author.Data.Link
                },
                CreatedDate = model.Created.DateTime,
                UpdatedDate = model.LastModified.DateTime
            };

            return result;
        }

        public Global MapToGlobal(GlobalEntity model)
        {
            return new Global()
            {
                SiteName = model.Data.SiteName,
                LinkFacebook = model.Data.LinkFacebook,
                LinkGithub = model.Data.LinkGithub,
                LinkTwitter = model.Data.LinkTwitter,
                LinkLinkedIn = model.Data.LinkLinkedIn,
                ImageFavicon = ResolveAssetURL(model.Data.ImageFavicon.First())
            };
        }

        public PageAbout MapToPage_About(PageAboutEntity model)
        {
            return new PageAbout()
            {
                BiographyHtml = model.Data.BiographyHtml,
                CVUrl = ResolveAssetURL(model.Data.CVUrl.First()),
                ImageHeader = ResolveAssetURL(model.Data.ImageHeaderAbout.First()),
                MetaDescription = model.Data.MetaDescription
            };
        }

        public PageContact MapToPage_Contact(PageContactEntity model)
        {
            return new PageContact()
            {
                EmailAddress = model.Data.EmailAddress,
                MetaDescription = model.Data.MetaDescription,
                ImageHeader = ResolveAssetURL(model.Data.ImageHeaderContact.First())
            };
        }

        public PageIndex MapToPage_Index(PageIndexEntity model)
        {
            return new PageIndex()
            {
                ImageHeader = ResolveAssetURL(model.Data.ImageHeaderIndex.First()),
                MetaDescription = model.Data.MetaDescription,
                Heading = model.Data.Heading,
                Subheading = model.Data.Subheading
            };
        }

        public PageProjects MapToPage_Projects(PageProjectsEntity model)
        {
            return new PageProjects()
            {
                ImageHeader = ResolveAssetURL(model.Data.ImageHeaderProjects.First()),
                MetaDescription = model.Data.MetaDescription
            };
        }

        public PageSearchResults MapToPage_SearchResults(PageSearchResultsEntity model)
        {
            return new PageSearchResults()
            {
                ImageHeader = model.Data.ImageHeaderSearchResults.First(),
                MetaDescription = model.Data.MetaDescription
            };
        }

        public Project MapToProject(ProjectEntity model)
        {
            return new Project()
            {
                Id = model.Id,
                Slug = model.Data.Slug,
                Title = model.Data.Title,
                BodyHtml = model.Data.BodyHtml,
                ExternalUrl = model.Data.ExternalUrl,
                ImageHeaderUrl = ResolveAssetURL(model.Data.ImageHeader.First()),
                ImageThumbnailUrl = ResolveAssetURL(model.Data.ImageThumbnail.First()),
                Subtitle = model.Data.Subtitle,
                MetaDescription = model.Data.MetaDescription,
                Tags = model.Data.Tags,
                CreatedDate = model.Created.DateTime,
                UpdatedDate = model.LastModified.DateTime
            };
        }
    }
}
