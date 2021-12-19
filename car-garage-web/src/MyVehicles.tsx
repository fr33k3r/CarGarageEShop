import * as React from "react";
import VehicleRow from "./VehicleRow";

export interface IState {
    loading: boolean;
    vehicles: IVehicle[];
}

export interface IVehicle {
    Id: number,
    Make: string,
    Model: string,
    YearModel: number,
    Price: number,
    Licensed: boolean,
    DateAdded: Date
}

export default class MyVehicles extends React.Component<any, IState>
{
    public state: IState = {
        loading: false,
        "vehicles" : []
    }

    public async componentDidMount() {
        this.setState({ loading: true }); // toggle on
        const result = await fetch('https://localhost:7072/api/Warehouses');
        const vehicles = await result.json();
        this.setState({ vehicles, loading: false }); // toggle off
    }

    public render() {
        return (
            <div>
                <h1>My Vehicles</h1>
                {this.state.loading && <div>Loading...</div>}  {/* show this while loading data */}
                <table className="vehicle-list">
                    <tbody>
                        {this.state.vehicles.map(vehicle => 
                        <VehicleRow key={vehicle.Id} vehicle={vehicle} />)}
                    </tbody>
                </table>
            </div>
        );
    }
}