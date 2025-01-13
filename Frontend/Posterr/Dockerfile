# Use the official Node.js image with the latest LTS version
FROM node:18-alpine

# Set the working directory
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code
COPY . .

# Expose the port the app runs on
EXPOSE 80

# Command to run the app
RUN npm run dev
# CMD ["npm", "run", "dev"]