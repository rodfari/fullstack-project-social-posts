const baseUrl = process.env.LOCAL_DOMAIN | process.env.REACT_APP_LOCAL_DOMAIN || process.env.DOCKER_DOMAIN

export const createPost = async (content) => {
    const response = await fetch(`${baseUrl}/posts`, {
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
    const response = await fetch(`${baseUrl}/posts/repost`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(content),
    });
    
    const data = await response.json();
    return data;
}

export const getPosts = async (keyword, sort) => {
    let url = `${baseUrl}/posts?`;
    if(keyword)
        url += `keyword=${keyword}&`;
    if(sort)
        url += `sort=${sort}&`;

    const response = await fetch(url);
    const status =  response.status;
    const data = await response.json();
    return data;
};


export const searchPost = async (keyword) => {
    const response = await fetch(`${baseUrl}/posts`,{
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
    const response = await fetch(`${baseUrl}/user`);
    const data = await response.json();
    return data;
};

export const getUserById = async (id) => {
    const response = await fetch(`${baseUrl}/user/${id}`);
    const data = await response.json();
    return data;
}