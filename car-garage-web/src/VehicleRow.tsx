import * as React from "react";

export default class VehicleRow extends React.Component<any, any>{

    public render(){
        return (
        <tr>
            <td className="avatar">Avatar</td>
            <td className="id">{this.props.vehicle.Id}</td>
            <td className="make">{this.props.vehicle.Make}</td>
            <td className="model">{this.props.vehicle.Model}</td>
            <td className="yearmodel">{this.props.vehicle.YearModel}</td>
            <td className="price">{this.props.vehicle.Price}</td>
            <td className="Licensed">{this.props.vehicle.Licensed}</td>
            <td className="DateAdded">{this.props.vehicle.DateAdded}</td>
        </tr>
        )
    }   
}
