using AutoMapper;
using System.Web;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using Transfer.Data;
using Transfer.Dtos;
using Transfer.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace Transfer.Controllers
{

    [Route("api")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITransferRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ITransferRepo repository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        //GET api
        [HttpGet("{p}")]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommmands(int p=1)
        {
            var commandItems = _repository.GetAllCommands(p);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        //GET api/id/{id}
        
        [HttpGet("id/{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null)
            {
                return Ok(commandItem);
            }
            return NotFound();
        }
        //GET api/search/{id}/{p}
        [HttpGet("search/{search}/{p}")]
        public ActionResult<CommandReadDto> GetCommandBySearch(string search, int p = 1)
        {
            var commandItem = _repository.GetCommandBySearch(search, p);
            if (commandItem != null)
            {
                return Ok(commandItem);
            }
            return NotFound();
        }
            //POST api/commands
            [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

          /*  var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { commandReadDto.Id }, commandReadDto);*/
            return Ok(commandModel);
        }

        [HttpPost("update")]
        public ActionResult<CommandReadDto> Dbupdate()
        {
            string ContentRootPath = _webHostEnvironment.ContentRootPath;
            string path = Path.Combine(ContentRootPath, "Veriler", "db.JSON");
            StreamReader reader = new StreamReader(path);
            string jsondata = reader.ReadToEnd();
            List<Command> cardlist = JsonConvert.DeserializeObject<List<Command>>(jsondata);
            foreach (var item in cardlist)
            {
                _repository.CreateCommand(item);
                _repository.SaveChanges();
            }
            return Ok();
        }


        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        //DELETE api/commands/{dbnm}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}
