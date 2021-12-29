import { useEffect, useState } from "react";
import configData from "./config.json";
import { QueryClient, QueryClientProvider, useQuery } from 'react-query'


//Components
import Item from './Components/Item/Item';
import Cart from './Components/Cart/Cart';
import Drawer from '@material-ui/core/Drawer';
import LinearProgress from "@material-ui/core/LinearProgress";
import Grid from "@material-ui/core/Grid";
import AddShoppingCartIcon from '@material-ui/icons/AddShoppingCart';
import Badge from '@material-ui/core/Badge';


//Styles
import { Wrapper, StyledButton } from "./App.styles";

//Types
export type CartItemType = {
  Id: number,
  WareHouseName: string,
  WareHouseLocation: ILocation,
  CarsLocation: string,
  Make: string,
  Model: string,
  YearModel: number,
  Price: number,
  Licensed: boolean,
  DateAdded: Date,
  amount: number,
  image: string
}

export interface ILocation {
  lat: string;
  long: string;
}

const getVehicles = async (): Promise<CartItemType[]> =>
    await (await fetch('https://localhost:7072/api/Warehouses', 
    {
        method: 'GET',
        headers:{
          Accept: 'application/json',
                   'Content-Type': 'application/json',
                   'Authorization': "Bearer " + configData.Token
                }
    })).json();

const cartFromLocalStorage = JSON.parse(localStorage.getItem('cart')  || '[]')
const queryClient = new QueryClient()

const App = () => {

  const [cartOpen, setCartOpen] = useState(false);
  const [cartItems, setCartItems] = useState(cartFromLocalStorage as CartItemType[])

  //Save cart to local storage
  useEffect(() => {
    localStorage.setItem('cart', JSON.stringify(cartItems));
  }, [cartItems])

  const { data, isLoading, error } = useQuery<CartItemType[]>('vehicles', getVehicles);
    
  const getTotalItems = (items: CartItemType[]) => 
    items.reduce((ack: number, item) => ack + item.amount, 0);

  const handleAddToCart = (clickedItem: CartItemType) => {
    setCartItems(prev => {
      //Check whether the item is already in the cart
      const isItemInCart = prev.find(item => item.Id === clickedItem.Id)
      if (isItemInCart){
        return prev.map(item => 
          item.Id === clickedItem.Id 
          ? { ...item, amount: item.amount + 1 }
            : item          
        );
      }
      // First time the item is added to the cart
      return [...prev, { ...clickedItem, amount: 1} ];
    });
  };

  const handleRemoveFromCart = (id: number) => {
    setCartItems(prev => (
      prev.reduce((ack, item) => {
        if (item.Id === id){
          if (item.amount === 1) return ack;
          return [...ack, {...item, amount: item.amount - 1}];
        } else {
          return [...ack, item];
        }

      },  [] as CartItemType[])
    ))
  };

  if (isLoading) return <LinearProgress/>;
  if (error) return <div>Error loading vehicle list ...</div>;

  return (    
    <QueryClientProvider client={queryClient}>            
    <Wrapper>      
      <h1>Welcome To Frank's Garage</h1>
      <Drawer anchor='right' open={cartOpen} onClose={() => setCartOpen(false) }>
        <Cart 
          cartItems={cartItems} 
          addToCart={handleAddToCart}
          removeFromCart={handleRemoveFromCart} 
        />
      </Drawer>
      <StyledButton onClick={() => setCartOpen(true)}>
        <Badge badgeContent={getTotalItems(cartItems)} color='error'>
          <AddShoppingCartIcon />
        </Badge>
      </StyledButton>      
      <Grid container spacing={3}>
        {
          data?.map(
            (
              item => 
              (
                <Grid item key={item.Id} xs={12} sm={4}>
                  <Item item={item} handleAddToCart={handleAddToCart} />
                </Grid>
              )
            ))
        }
      </Grid>      
    </Wrapper>  
    </QueryClientProvider>  
  );
};

export default function Wraped(){
  return(<QueryClientProvider client={queryClient}>
          <App/>
      </QueryClientProvider>
  );
}