using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shop.domain.Entities;
using shop.domain.Extensions;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.Product;
using shop.service.Interfaces;
using System.Net.Mime;

namespace shop.api.Controllers;

[ApiController]
[Route("api/products")]
[Produces("application/json")]
[Consumes(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public ProductController(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    /// <summary>
    /// Consultar produtos
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(PagedList<ProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] ProductParameters parameters)
    {
        PagedList<ProductResponse> pagedListProduct = await _service.GetAll(parameters);

        return Ok(pagedListProduct);
    }

    /// <summary>
    /// Consultar produto pelo id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _service.GetById(id);

        if (product.IsNull())
            return NotFound();

        return Ok(_mapper.Map<ProductResponse>(product));
    }

    /// <summary>
    /// Criar produto
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] ProductRequestBody requestBody)
    {
        var newProduct = _mapper.Map<Product>(requestBody);

        var createdProduct = await _service.Add(newProduct);

        createdProduct = await _service.GetById(createdProduct.Id);

        return Created(_mapper.Map<ProductResponse>(createdProduct));
    }

    /// <summary>
    /// Alterar produto
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] ProductRequestBody requestBody)
    {
        var updatedProduct = await _service.Update(id, _mapper.Map<Product>(requestBody));

        if (updatedProduct.IsNull())
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Deletar produto
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deletedProduct = await _service.Delete(id);

        if (deletedProduct.IsNull())
            return NotFound();

        return NoContent();
    }
}
