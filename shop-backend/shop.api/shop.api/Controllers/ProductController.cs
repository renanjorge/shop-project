using Microsoft.AspNetCore.Mvc;
using shop.domain.Extensions;
using shop.domain.Interfaces.Services;
using shop.domain.Models.DTOs;
using shop.domain.Models.DTOs.Product;
using shop.domain.Models.Parameters;
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

    public ProductController(IProductService service) => _service = service;

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
        ProductResponse product = await _service.GetById(id);

        if (product.IsNull())
            return NotFound();

        return Ok(product);
    }

    /// <summary>
    /// Criar produto
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] ProductRequestBody requestBody)
    {
        ProductResponse createdProduct = await _service.Add(requestBody);

        createdProduct = await _service.GetById(createdProduct.Id);

        return Created(createdProduct);
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
        ProductResponse updatedProduct = await _service.Update(id, requestBody);

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
        ProductResponse deletedProduct = await _service.Delete(id);

        if (deletedProduct.IsNull())
            return NotFound();

        return NoContent();
    }
}
