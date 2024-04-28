using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace tpmodul10_1302220046.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Static list to store Mahasiswa data
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa ("Muhammad Farhan Ismali Fentarto", "1302220046" ),
            new Mahasiswa ( "Kevin Albany Junaidi", "1302223027" ),
            new Mahasiswa ( "Adrian Fahren Setiawan", "1302220018" ),
            new Mahasiswa ( "Rindang Bani Isyan", "1302223023" ),
            new Mahasiswa ( "Adib Faizulhaq Armadhani", "1302223110" ),
        };

        [HttpGet]
        public IEnumerable<Mahasiswa> Get()
        {
            return mahasiswaList;
        }

        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            if (index >= 0 && index < mahasiswaList.Count)
            {
                return Ok(mahasiswaList[index]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa mahasiswa)
        {
            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(Get), new { index = mahasiswaList.Count - 1 }, mahasiswa);
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index >= 0 && index < mahasiswaList.Count)
            {
                mahasiswaList.RemoveAt(index);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
