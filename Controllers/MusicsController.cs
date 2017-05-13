using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using Comment.Models;

namespace Comment.Controllers
{
	
    public class MusicsController : ApiController
    {
        private readonly CommentDb _db = new CommentDb();



        [ResponseType(typeof(String))]
        public IHttpActionResult Getcomment(int id)
        {
            var comment = _db.comment.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [ResponseType(typeof(String))]
        public IHttpActionResult PutMusic(int id, String comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.Id)
            {
                return BadRequest();
            }

            _db.Entry(comment).State = EntityState.Modified;

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
	            if (!StringExists(id))
                {
                    return NotFound();
                }
	            throw;
            }

	        return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Post(String comment)
        {
			
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_db.comment.Add(comment);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comment/5
        [ResponseType(typeof(String))]
        public IHttpActionResult Deletecomment(int id)
        {
            var comment = _db.comment.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            _db.comment.Remove(comment);
            _db.SaveChanges();

            return Ok(music);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool commentExists(int id)
        {
            return _db.comment.Count(e => e.Id == id) > 0;
        }
    }
}