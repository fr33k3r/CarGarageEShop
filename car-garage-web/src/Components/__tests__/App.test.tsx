import React from 'react';
import { render, screen } from '@testing-library/react';
import App, { CartItemType } from '../../App';
import { Wrapper } from '../../App.styles';
import Item from '../Item/Item';

describe('When everything is OK', () =>{
    test('should render the app component without crashing', () => {
        render(<App />);    
        screen.debug();
    })
})


it('Renders renders a progress bar', () => {
    render(<App />);
    screen.getByRole("progressbar");
})



