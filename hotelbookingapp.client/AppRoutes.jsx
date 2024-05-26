import { BookingPage } from './components/BookingPage';


const AppRoutes = () => [
    {
        index: true,
        element: <Main />,
    },
    {
        path: '/booking',
        element: <BookingPage />,
    }
];

export default AppRoutes;