using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prelim_exam_jintalan_mikaela.Models;
using System.Linq;
using System.Threading.Tasks;

namespace prelim_exam_jintalan_mikaela.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly MovieContext _DB;

        public DirectorsController(MovieContext DB)
        {
            _DB = DB;
        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
            return View(await _DB.Directors.ToListAsync());
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _DB.Directors
                .Include(i => i.Movies)
                .FirstOrDefaultAsync(m => m.id == id);
            if (director == null)
            {
                return NotFound();
            }

            var movies = await _DB.Movies.Where(i => !i.DirectorID.HasValue).ToArrayAsync();

            var model = new DirectorVM
            {
                Director = director,
                DirectorID = director.id,
            };

            model.Movies = new SelectList(
                movies.Select(i => new SelectListItem
                {
                    Text = i.Title,
                    Value = i.id.ToString(),
                }), "Value", "Text");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(DirectorVM model)
        {
            if (model.MovieID.HasValue)
            {
                var movie = await _DB.Movies.FindAsync(model.MovieID);
                movie.DirectorID = model.DirectorID;

                _DB.Movies.Update(movie);

                await _DB.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Details), new { id = model.DirectorID });
        }


        public async Task<IActionResult> RemoveMovie(int id)
        {
            var movie = await _DB.Movies.FindAsync(id);

            var directorID = movie.DirectorID;

            movie.DirectorID = null;

            _DB.Movies.Update(movie);

            await _DB.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = directorID });
        }

        #region Create

        // GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name")] Director director)
        {
            if (ModelState.IsValid)
            {
                _DB.Add(director);
                await _DB.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        #endregion Create

        #region Edit

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _DB.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        // POST: Directors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name")] Director director)
        {
            if (id != director.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _DB.Update(director);
                    await _DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        #endregion Edit

        #region Delete

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _DB.Directors
                .FirstOrDefaultAsync(m => m.id == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director = await _DB.Directors.FindAsync(id);
            _DB.Directors.Remove(director);
            await _DB.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion Delete

        private bool DirectorExists(int id)
        {
            return _DB.Directors.Any(e => e.id == id);
        }
    }
}