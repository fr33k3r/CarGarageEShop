import * as React from "react";
//import Modal from './Modal.js';

export default class VehicleRow extends React.Component<any, any> {
    
    constructor(props: any) {
        super(props);
        this.state = {
            show : true
        };
        this.showModal = this.showModal.bind(this);
        this.hideModal = this.hideModal.bind(this);
    }

    showModal = () => {
        this.setState({ show: true});
    };

    hideModal = () => {
        this.setState({ show: false});
    };

    // public showTheModal(){        
    //     return
    //         <Modal show={this.state.show} handleClose={this.hideModal}>
    //             <p>Modal</p>
    //         </Modal>           
    // };

    public render(){
        return (               
        <tr /*onClick={this.showTheModal}*/>            
            <td className="id">{this.props.vehicle.Id}</td>
            <td className="make">{this.props.vehicle.Make}</td>
            <td className="model">{this.props.vehicle.Model}</td>
            <td className="yearmodel">{this.props.vehicle.YearModel}</td>
            <td className="price">{this.props.vehicle.Price}</td>
            <td className="Licensed">{this.props.vehicle.Licensed ? "Licensed" : "Not Licensed"}</td>
            <td className="DateAdded">{this.props.vehicle.DateAdded}</td>            
        </tr>        
        )
    }   
}
