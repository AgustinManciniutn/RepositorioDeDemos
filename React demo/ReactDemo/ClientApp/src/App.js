
import "bootstrap/dist/css/bootstrap.min.css"
import { useEffect, useState } from "react";

const App = () => {

    const [Products, setProducts] = useState([]);

    const [brand, setBrand] = useState("");
    const [model, setModel] = useState("");
    const [category, setCategory] = useState("");
    const [price, setPrice] = useState("");
    const [stock, setStock] = useState("");


    const mostrarTareas = async () => {

        const response = await fetch("api/tarea/List");

      
      
        const data = await response.json();

        setProducts(data);
      
        console.log(data);
  

   

    }

    useEffect(() => {
        mostrarTareas();

    }, [])

    async function AddProduct(event){
        event.preventDefault()

        const prod = {
            Id : 'temp',
            Brand: brand,
            Model: model,
            Category: category,
            Stock: stock,
            Price: price,
            ImagePath : 'empty'
        };

        console.log(prod);

        const response = await fetch("api/tarea/AddProduct", {
            method: "POST",
            mode: 'cors',
            cache: 'no-cache',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(prod)
        })

        if (response.ok) {

            setBrand("");
            setModel("");
            setStock("");
            setPrice("");
            setCategory("");

            await mostrarTareas();
        }
    }

    const deleteProduct = async (id) => {

        const response = await fetch("api/tarea/DeleteProduct/" + id, {
            method: "DELETE"
        })

        if (response.ok) {
            await mostrarTareas();
        }
    }




    return (
        <div className="MainContainer col-sm-12 bg-dark p-5">

            <h1 className="text-white px-5">Product List</h1>
            <div className="FirstSection row ">
                <div className="col-sm-12 d-flex">
                     
                    <div className="col-sm-6 p-5">

                        <h1 className="text-light"> Enter the values for a product and fill a list of products below. </h1>

                    </div>

                    <form id="ProductForm" className="col-sm-6 p-2" onSubmit={AddProduct}>

                        <div className="d-flex flex-column p-5" >
                            <h3 className="text-light">Input the product values:</h3>
                            <input type="text" className="form-control" value={brand} placeholder="Brand" name="Brand" onChange={(e) => setBrand(e.target.value)} />

                            <input type="text" className="form-control" value={model} placeholder="Model" name="Model" onChange={(e) => setModel(e.target.value)} />
                            {/*<input type="text" className="form-control" value={category} placeholder="Category" name="Category" onChange={(e) => setCategory(e.target.value)} />*/}
                   
                            <select className="form-control my-2" value={category} name="category" id="category" onChange={(e) => { setCategory(e.target.value);}}>
                                <option value="GPU">GPU</option>
                                <option value="CPU">CPU</option>
                                <option value="Motherboard">Motherboard</option>
 
                            </select>

                            <input type="number" min="0" className="form-control" value={stock} placeholder="Initial Stock" name="Stock" onChange={(e) => setStock(e.target.value)} />
                            <input type="text" className="form-control" value={price} placeholder="Price" name="Price" onChange={(e) => setPrice(e.target.value)} />

                            <div className=" col-sm-12 d-flex flex-row-reverse px-1">

                                <button className="ml-fill btn btn-success col-sm-3 float-right" type="submit" onClick={(event) => AddProduct(event)}>Add </button>
                            </div>

                        </div>

                    </form>
                </div>
            </div>

            <div className="col-sm-12 d-flex bg-dark justify-content-center ">


                    <div className="list-group d-flex col-sm-8">

                        {
                            Products.map(
                                (item) => (

                                    <div key={item.id} className="list-group-item text-dark  list-group-item-action">
                                        <div className="d-flex"> 
                                            <h5 className="text-primary text-dark">{item.brand}</h5>    
                                            <h5 className=" text-dark"> &nbsp;{item.model}</h5>  
                                        </div>
                                        <div className="d-flex justify-content-between ">

                                            <div> Category: <span className="text-dark">{item.category}</span></div>

                                            <div> Stock: <span className="text-dark">{item.stock} &nbsp; unidades</span></div>

                                            <div className="d-flex">
                                                <h5 className="text-primary text-dark">Price: </h5>
                                                <span className="text-dark">${item.price}</span>
                                            </div>
                                            <button className="btn btn-sm btn-outline-danger" onClick={() => deleteProduct(item.id) } >Delete</button>

                                        </div>

                                    </div>
                               
                                )
                            )
                        }

                    </div>

            </div>
        </div>
        )
}


export default App;