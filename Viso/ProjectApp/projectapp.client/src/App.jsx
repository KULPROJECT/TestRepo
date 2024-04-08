import { Route, Routes } from 'react-router-dom';
import LoginForm from './Components/LoginForm/LoginForm';
import CreateUser from './Components/CreateUser/CreateUser';


function App() {
    return (
        <>
            <Routes>
                <Route path="/" element={<LoginForm />} />
                <Route path="/createuser" element={<CreateUser />} />
            </Routes>
        </>
    )
}
export default App;