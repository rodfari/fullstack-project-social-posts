
export const createPost = async (content) => {
    const response = await fetch('http://localhost:5006/api/Posts', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(content),
    });
    const data = await response.json();
    return data;
};

export const getPosts = async () => {
    const response = await fetch('http://localhost:5006/api/Posts');
    const data = await response.json();
    return data;
};

