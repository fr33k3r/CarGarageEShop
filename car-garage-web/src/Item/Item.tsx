import Button from  '@material-ui/core/Button';

//Types
import { CartItemType } from '../App';

//Styles
import { Wrapper } from './Item.styles';

type Props = {
    item: CartItemType;
    handleAddToCart: (clickedItem: CartItemType) => void;
}

const Item: React.FC<Props> = ({ item, handleAddToCart}) => (
    <Wrapper>
        <img src = 'https://as2.ftcdn.net/v2/jpg/02/69/56/91/1000_F_269569184_37mGd744FHFN7GEPkYECWM4o47f5lw4e.jpg' alt = 'Not available' />
        <div>
            <div className="grid-container">
                <div className="grid-child purple">
                    <h3>{item.Make}</h3>
                    <p>{item.Model}</p>
                    <h3>${item.Price}</h3>                     
                </div>
                <div className="grid-child green">
                    <h3>{item.WareHouseName}</h3>  
                    <p>{item.CarsLocation}</p>
                    <h3>{item.DateAdded}</h3>   
                </div>
            </div>
        </div>
        <Button onClick={() => handleAddToCart(item)}>Add To Cart</Button>
    </Wrapper>

)

export default Item;