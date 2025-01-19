const env = process.env;
const environment = env.REACT_APP_ENV;
const API_URL = 
environment === 'development' ? env.REACT_APP_DEV_URL : env.REACT_APP_PROD_URL;

export const createPost = async (content) => {
    const response = await fetch(`${API_URL}/posts`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(content),
    });
    
    const data = await response.json();
    return data;
};

export const createRepost = async (content) => {
    const response = await fetch(`${API_URL}/posts/repost`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(content),
    });
    
    const data = await response.json();
    return data;
}

export const getPosts = async (page, pageSize, keyword, sort) => {
    // console.log(page, pageSize, keyword, sort);
    let url = `${API_URL}/posts?page=${page}&pageSize=${pageSize}`;
    if(keyword)
        url += `&keyword=${keyword}`;
    if(sort)
        url += `&sort=${sort}`;
    console.log(url);
    const response = await fetch(`${url}`);
    const status =  response.status;
    const data = await response.json();
    return data;
};


export const searchPost = async (keyword) => {
    const response = await fetch(`${API_URL}/posts`,{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(keyword),
    });
    const data = await response.json();
    return data;
};


export const getUsers = async () => {
    const response = await fetch(`${API_URL}/user`);
    const data = await response.json();
    return data;
};

export const getUserById = async (id) => {
    const response = await fetch(`${API_URL}/user/${id}`);
    const data = await response.json();
    return data;
}