import styled from "styled-components";
import IconButton from '@material-ui/core/IconButton'
export const Wrapper = styled.div`
    margin: 40px;       

    h1 { 
        color: #111; 
        font-family: 'Helvetica Neue', sans-serif; 
        font-size: 55px; 
        font-weight: bold; 
        letter-spacing: -1px; 
        line-height: 1; 
        text-align: center; 
    }

        // h1 {
        //     background: #2B6695;
        //     border-radius: 6px 6px 6px 6px;
        //     box-shadow: 0 0 0 1px #5F5A4B, 1px 1px 6px 1px rgba(10, 10, 0, 0.5);
        //     color: #FFFFFF;
        //     Font family: "Microsoft YaHei", "Tahoma", "boldface", Arial;
        //     font-size: 18px;
        //     font-weight: bold;
        //     height: 25px;
        //     line-height: 25px;
        //     margin: 18px 0 !important;
        //     padding: 8px 0 5px 5px;
        //     text-shadow: 2px 2px 3px #222222;
        // }
`;

export const StyledButton = styled(IconButton)`
    position: fixed;
    z-index: 100;
    right: 20px;
    top: 20px;    
`
