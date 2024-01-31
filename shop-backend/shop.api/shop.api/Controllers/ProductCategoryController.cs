using Microsoft.AspNetCore.Mvc;
using shop.domain.Extensions;
using shop.domain.Parameters;
using shop.service.DTOs;
using shop.service.DTOs.ProductCategory;
using shop.service.Interfaces;
using System.Net.Mime;

namespace shop.api.Controllers;

[Route("api/product-categories")]
[ApiController]
[Produces("application/json")]
[Consumes(MediaTypeNames.Application.Json)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryService _service;

    public ProductCategoryController(IProductCategoryService service) => _service = service;

    /// <summary>
    /// Consultar categorias dos produtos
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(PagedList<ProductCategoryResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get([FromQuery] ProductCategoryParameters parameters)
    {
        PagedList<ProductCategoryResponse> pagedListProductCategory = await _service.GetAll(parameters);

        return Ok(pagedListProductCategory);
    }

    /// <summary>
    /// Consultar categoria do produto pelo id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductCategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        ProductCategoryResponse productCategory = await _service.GetById(id);

        if (productCategory.IsNull())
            return NotFound();

        return Ok(productCategory);
    }

    /// <summary>
    /// Criar categoria do produto
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ProductCategoryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] ProductCategoryRequestBody requestBody)
    {
        ProductCategoryResponse createdProductCategory = await _service.Add(requestBody);

        return Created(createdProductCategory);
    }

    /// <summary>
    /// Alterar categoria do produto
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] ProductCategoryRequestBody requestBody)
    {
        ProductCategoryResponse updatedProductCategory = await _service.Update(id, requestBody);

        if (updatedProductCategory.IsNull())
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Deletar categoria do produto
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        ProductCategoryResponse deletedProductCategory = await _service.Delete(id);

        if (deletedProductCategory.IsNull())
            return NotFound();

        return NoContent();
    }
}