using MediaApi.Domain;
using MediaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaApi.Controllers
{
    public class MediaController: ControllerBase
    {
        MediaDataContext Context;

        public MediaController(MediaDataContext context)
        {
            Context = context;
        }

        [HttpPost("media")]
        public async Task<IActionResult> AddMedia([FromBody] PostMediaRequest mediaToAdd)
        {

            // ADD A FAKE DELAY to simulate a more "real world"
            await Task.Delay(3000);
            // 1. Make sure it is valid.
            //  -- If it is not, return a 400 with some error information if you want.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                // 2. Add it to the database.
                var media = new MediaItem
                {
                    Title = mediaToAdd.Title,
                    Kind = mediaToAdd.Kind,
                    Consumed = false,
                    DateConsumed = null,
                    RecommendedBy = mediaToAdd.RecommendedBy,
                    Removed = false
                };
                Context.MediaItems.Add(media);
                await Context.SaveChangesAsync();
                var response = new MediaResponseItem
                {
                    Id = media.Id,
                    Title = media.Title,
                    Consumed = media.Consumed,
                    DateConsumed = media.DateConsumed,
                    Kind = media.Kind,
                    RecommendedBy = media.RecommendedBy
                };
                // 3. Return a 201 (Created) status code.
                // 4. Return a Location header with the URL of the new resource
                // 5. It's nice just to give them a copy of the new resource.
                // TEMP.
                return CreatedAtRoute("media#getbyid", new { id = response.Id }, response);
            }
            
        }

        [HttpGet("media/{id:int}", Name = "media#getbyid")]
        public async Task<IActionResult> GetAMediaItem(int id)
        {
            var item = await Context.MediaItems
                .Where(m => m.Removed == false && m.Id == id)
                .Select(m => new MediaResponseItem
                {
                    Id = m.Id,
                    Title = m.Title,
                    RecommendedBy = m.RecommendedBy,
                    Consumed = m.Consumed,
                    DateConsumed = m.DateConsumed,
                    Kind = m.Kind
                }).SingleOrDefaultAsync();
            if(item == null)
            {
                return NotFound("No item with that id.");
            } else
            {
                return Ok(item);
            }
        }



        // GET /media?kind=game
        [HttpGet("media")]
        public async Task<IActionResult> GetAllMedia([FromQuery] string kind = "All")
        {
            var query = Context.MediaItems
                .Where(m => m.Removed == false)
                .Select(m => new MediaResponseItem
                {
                    Id = m.Id,
                    Title = m.Title,
                    Consumed = m.Consumed,
                    DateConsumed = m.DateConsumed,
                    Kind = m.Kind,
                    RecommendedBy = m.RecommendedBy
                });
            if(kind != "All")
            {
                query = query.Where(q => q.Kind == kind);
            }
            var response = new GetMediaResponse
            {
                Data = await query.ToListAsync(),
                FilteredBy = kind
            };
            return Ok(response);
            // 1. Create a Model and Project (select) into it.
            // 2. This should be an asynchronous call. We are using up a valuable
            //    thread of execution just waiting for the database query to run.
        }
    }
}
