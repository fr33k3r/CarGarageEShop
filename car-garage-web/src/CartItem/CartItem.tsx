import Button from '@material-ui/core/Button';

//Types
import { CartItemType } from '../App';
import Item from '../Item/Item';

//Styles
import {Wrapper} from './CartItem.styles';

type Props = {
    item: CartItemType;
    addToCart: (clickedItem: CartItemType) => void;
    removeFromCart: (id: number) => void;

}

const CartItem: React.FC<Props> = ({item, addToCart, removeFromCart}) => (
    <Wrapper>
        <div>        
            <h3>{item.Make}</h3>
            <div className="information">
                <p>Price: ${item.Price}</p>                
                <div className="buttons">
                    <Button size="small" disableElevation variant="contained" onClick={() => removeFromCart(item.Id)}>-</Button>
                    <p>{item.amount}</p>
                    <Button size="small" disableElevation variant="contained" onClick={() => addToCart(item)}>+</Button>
                </div>               
            </div>
            <p>Total: ${item.amount * item.Price}</p>
        </div>
        <img src = 'https://as2.ftcdn.net/v2/jpg/02/69/56/91/1000_F_269569184_37mGd744FHFN7GEPkYECWM4o47f5lw4e.jpg' width="200" 
     height="132"  alt = 'Not available' />
    </Wrapper>
);

export default CartItem;
